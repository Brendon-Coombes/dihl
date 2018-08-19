import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface PlayerStatisticsState {
    isLoading: boolean;
    minimumGamesPlayed?: number;
    statistics: PlayerStatistic[];
}

export interface PlayerStatistic {
    id: string;
    goals: number;
    assists: number;
    primaryAssits: number;
    secondaryAssists: number;
    points: number;
    gamesPlayed: number;
    pointsPerGame: number;
    penaltyMinutes: number;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestPlayerStatisticsAction {
    type: 'REQUEST_PLAYER_STATISTICS';
    minimumGamesPlayed: number;
}

interface ReceivePlayerStatisticsAction {
    type: 'RECEIVE_PLAYER_STATISTICS';
    minimumGamesPlayed: number;
    playerStatistics: PlayerStatistic[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestPlayerStatisticsAction | ReceivePlayerStatisticsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestPlayerStatistics: (minimumGamesPlayed: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        if (minimumGamesPlayed !== getState().playerStatistics.minimumGamesPlayed) {
            //TODO BC: Point at correct API
            let fetchTask = fetch(`api/Statistics/PlayerStatistics?minimumGamesPlayed=${ minimumGamesPlayed }`)
                .then(response => response.json() as Promise<PlayerStatistic[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_PLAYER_STATISTICS', minimumGamesPlayed: minimumGamesPlayed, playerStatistics: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_PLAYER_STATISTICS', minimumGamesPlayed: minimumGamesPlayed });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: PlayerStatisticsState = { statistics: [], isLoading: false };

export const reducer: Reducer<PlayerStatisticsState> = (state: PlayerStatisticsState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_PLAYER_STATISTICS':
            return {
                minimumGamesPlayed: action.minimumGamesPlayed,
                statistics: state.statistics,
                isLoading: true
            };
        case 'RECEIVE_PLAYER_STATISTICS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.minimumGamesPlayed === state.minimumGamesPlayed) {
                return {
                    minimumGamesPlayed: action.minimumGamesPlayed,
                    statistics: action.playerStatistics,
                    isLoading: false
                };
            }
            break;
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};

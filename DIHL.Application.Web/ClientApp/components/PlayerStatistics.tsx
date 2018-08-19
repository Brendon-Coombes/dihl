import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as PlayerStatisticsState from '../store/PlayerStatistics';

// At runtime, Redux will merge together...
type PlayerStatisticsProps =
    PlayerStatisticsState.PlayerStatisticsState       // ... state we've requested from the Redux store
    & typeof PlayerStatisticsState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ minimumGamesPlayed: string }>; // ... plus incoming routing parameters

class PlayerStatistics extends React.Component<PlayerStatisticsProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        let minimumGamesPlayed = parseInt(this.props.match.params.minimumGamesPlayed) || 0;
        this.props.requestPlayerStatistics(minimumGamesPlayed);
    }

    componentWillReceiveProps(nextProps: PlayerStatisticsProps) {
        // This method runs when incoming props (e.g., route params) change
        let minimumGamesPlayed = parseInt(nextProps.match.params.minimumGamesPlayed) || 0;
        this.props.requestPlayerStatistics(minimumGamesPlayed);
    }

    public render() {
        return <div>
            <h1>Player Statistics</h1>
            <p>Player Leaders</p>
            { this.renderPlayerStatisticsTable() }
            { this.renderPagination() }
        </div>;
    }

    private renderPlayerStatisticsTable() {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Goals</th>
                    <th>Assists</th>
                    <th>Points</th>
                    <th>Games Played</th>
                    <th>Points Per Game</th>
                    <th>Penalty Minutes</th>
                </tr>
            </thead>
            <tbody>
            {this.props.statistics.map(statistic =>
                <tr key={ statistic.id }>
                    <td>{ statistic.goals }</td>
                    <td>{ statistic.assists }</td>
                    <td>{ statistic.points }</td>
                    <td>{ statistic.gamesPlayed }</td>
                    <td>{ statistic.pointsPerGame }</td>
                    <td>{ statistic.penaltyMinutes }</td>
                </tr>
            )}
            </tbody>
        </table>;
    }

    private renderPagination() {
        let previousGamesPlayed = (this.props.minimumGamesPlayed || 0) - 5;
        let nextGamesPlayed = (this.props.minimumGamesPlayed || 0) + 5;

        return <p className='clearfix text-center'>
            <Link className='btn btn-default pull-left' to={ `/stats/${ previousGamesPlayed }` }>Previous</Link>
            <Link className='btn btn-default pull-right' to={ `/stats/${ nextGamesPlayed }` }>Next</Link>
            { this.props.isLoading ? <span>Loading...</span> : [] }
        </p>;
    }
}

export default connect(
    (state: ApplicationState) => state.playerStatistics, // Selects which state properties are merged into the component's props
    PlayerStatisticsState.actionCreators                 // Selects which action creators are merged into the component's props
)(PlayerStatistics) as typeof PlayerStatistics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Client.Core.Domain;
using DIHL.Client.Core.Services.Contracts;

namespace DIHL.Client.Core.Services
{
    public class GenericListService : IGenericListService
    {
	    private readonly List<string> _presents = new List<string>
	    {
		    "Bicycle",
		    "Surfboard",
		    "Skateboard",
		    "Motorbike",
		    "Skis",
		    "Skates",
		    "Snowboard",
		    "Chocolate",
		    "Climbing gear",
		    "Squash racket",
		    "Bike rack"
	    };

		private readonly List<string> _peopleNames = new List<string>
	    {
		    "Julian Robinson",
		    "Hamish Dobson",
		    "Véronique Manti",
		    "Natalia Golovacheva",
		    "David Clayton",
		    "Jason Butler",
		    "Simon de Vries",
		    "Haydon Baddock",
		    "Brendon Coombes",
		    "Victor Usoltsev",
		    "Sunil Khuttan"
	    };

		private readonly Random _random;

		public GenericListService()
        {
            _random = new Random();
        }
		
        public Task<IEnumerable<ChristmasPresent>> GetChristmasPresentsAsync()
        {
            var christmasPresents = Enumerable.Range(0, 6).Select(_ => WrapPresent());
            return Task.FromResult(christmasPresents);
        }

        private ChristmasPresent WrapPresent()
        {
            return new ChristmasPresent(
                _presents[_random.Next(0, _presents.Count - 1)],
                _peopleNames[_random.Next(0, _peopleNames.Count - 1)],
                _peopleNames[_random.Next(0, _peopleNames.Count - 1)]);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repository
{
	public class RaceRepository : IRaceRepository
	{
		private readonly ApplicationDBContext _context;

		public RaceRepository(ApplicationDBContext context)
		{
			this._context = context;
		}

		public bool Add(Race race)
		{
			_context.Add(race);
			return Save();
		}

		public bool Update(Race race)
		{
			_context.Update(race);
			return Save();
		}

		public bool Delete(Race race)
		{
			_context.Remove(race);
			return Save();
		}

		public bool Save()
		{
			var result = _context.SaveChanges();
			return result > 0 ? true : false;
		}

		public async Task<IEnumerable<Race>> GetAll()
		{
			return await _context.Races.ToListAsync();
		}

		public async Task<IEnumerable<Race>> GetRaceByCity(string city)
		{
			return await _context.Races.Where(
				p => p.Address.City.Contains(city)).ToListAsync();
		}

		public async Task<Race> GetRaceByIdAsync(int id)
		{
			return await _context.Races.Include(
				p => p.Address).FirstOrDefaultAsync(
				p => p.Id == id);
		}
	}
}

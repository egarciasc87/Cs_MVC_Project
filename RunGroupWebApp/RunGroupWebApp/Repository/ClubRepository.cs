using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repository
{
	public class ClubRepository : IClubRepository
	{
		private readonly ApplicationDBContext _context;

		public ClubRepository(ApplicationDBContext context)
		{
			this._context = context;
		}

		public bool Add(Club club)
		{
			_context.Add(club);
			return Save();
		}

		public bool Update(Club club)
		{
			_context.Update(club);
			return Save();
		}

		public bool Delete(Club club)
		{
			_context.Remove(club);
			return Save();
		}

		public bool Save()
		{
			var result = _context.SaveChanges();
			return result > 0 ? true : false;
		}

		public async Task<IEnumerable<Club>> GetAll()
		{
			return await _context.Clubs.ToListAsync();
		}

		public async Task<IEnumerable<Club>> GetClubByCity(string city)
		{
			return await _context.Clubs.Where(
				p => p.Address.City.Contains(city)).ToListAsync();
		}

		public async Task<Club> GetClubByIdAsync(int id)
		{
			return await _context.Clubs.Include(
				p => p.Address).FirstOrDefaultAsync(
				p => p.Id ==id);
		}
	}
}

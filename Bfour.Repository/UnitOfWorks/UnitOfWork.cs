using System;
using Bfour.Core.UnitOfWorks;

namespace Bfour.Repository.UnitOfWorks
{
	public class UnitOfWork:IUnitOfWorks
	{
        private AppDbContex _appDbContex;
		public UnitOfWork(AppDbContex appDbContex)
		{
            _appDbContex = appDbContex;
		}

        public void Commit()
        {
            _appDbContex.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContex.SaveChangesAsync();
        }
    }
}


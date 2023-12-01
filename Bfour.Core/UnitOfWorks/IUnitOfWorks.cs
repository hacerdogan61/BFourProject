using System;
namespace Bfour.Core.UnitOfWorks
{
	public interface IUnitOfWorks
	{
		Task CommitAsync();
		void Commit();
	}
}


using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class vw_ClientContributionRepository : EFRepository<vw_ClientContribution>, Ivw_ClientContributionRepository
	{

	}

	public  interface Ivw_ClientContributionRepository : IRepository<vw_ClientContribution>
	{

	}
}
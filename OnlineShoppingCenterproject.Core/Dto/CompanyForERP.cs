using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto
{
	public class CompanyForERP
	{
		public CompanyForERP()
		{
			ERPIsClick = false;
			SoldOutPrice = 0;
			SoldOutQuantity = 0;
			ExistingQuantity = 0;
		}
		public Boolean ERPIsClick { get; set; }
		public double SoldOutPrice { get; set; }
		public long SoldOutQuantity { get; set; }
		public long ExistingQuantity { get; set; }
	}
}

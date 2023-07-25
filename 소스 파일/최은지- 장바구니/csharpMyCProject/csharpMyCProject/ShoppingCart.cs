using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpMyCProject
{
	public class ShoppingCart
	{
		//품목
		public string item { get; set; }

		//개수
		public int count { get; set; }

		//금액
		public int pay{ get; set; } 

		//바코드
		public string barcode { get; set; }
	}
}

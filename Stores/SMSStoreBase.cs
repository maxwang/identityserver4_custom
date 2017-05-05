using CustomDbProfileService2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDbProfileService2.Stores
{
	public abstract class SMSStoreBase : SMSISBaseClass
	{
		//protected readonly Id4Context db;

		//public SMSStoreBase(Id4Context context)
		//{
		//	this.db = context;
		//}
		public SMSStoreBase(Id4Context context) : base(context)
		{
		}
	}
}

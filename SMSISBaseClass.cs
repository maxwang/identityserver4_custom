using CustomDbProfileService2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDbProfileService2
{
    public abstract class SMSISBaseClass
    {
		protected readonly Id4Context db;

		public SMSISBaseClass(Id4Context context)
		{
			this.db = context;
		}
	}
}

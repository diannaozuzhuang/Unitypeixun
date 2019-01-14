using System;
using UnityEngine;


namespace AssemblyCSharp
{
	[Serializable]
	public struct zidian
	{
		public String str;
		public int pd;
		public void shexian(String st)
		{
			if (str.Equals (st)) {
				if (pd == 0) {
					this.pd = 1;
				} else {
					this.pd = 0;
				}
					
			}
		}
	}
}


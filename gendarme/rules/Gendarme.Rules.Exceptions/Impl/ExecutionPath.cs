using System;
using System.Collections.Generic;
using System.Linq;

using Mono.Cecil.Cil;

namespace Gendarme.Rules.Exceptions.Impl {

	public class ExecutionPathCollection : List<ExecutionBlock> {
	
		public ExecutionPathCollection ()
		{
		}

		private ExecutionPathCollection (ExecutionPathCollection coll)
		{
			foreach (ExecutionBlock block in coll)
				Add (block.Clone ());
		}

		public bool Contains (Instruction instruction)
		{
			return this.Any (block => block.Contains (instruction));
		}

		public ExecutionPathCollection Clone ()
		{
			return new ExecutionPathCollection (this);
		}
	}
}

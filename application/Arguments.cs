using netSimpleHostConnection;

namespace application
{
	class Arguments
	{
		[Argument(ArgumentType.Required)]
		public string Content;

		[Argument(ArgumentType.AtMostOnce, DefaultValue = 300)]
		public int DPI;

		[Argument(ArgumentType.AtMostOnce, DefaultValue = 300)]
		public int Size;

		[Argument(ArgumentType.AtMostOnce)]
		public string Output;
	}
}
using System;
using System.Threading;
using System.ServiceModel;


namespace Server
{
	/// <summary>
	/// Service.
	/// </summary>
	class Service : IService
	{
		/// <summary>
		/// Service logic.
		/// </summary>
		private ServiceLogic logic = new ServiceLogic();

		/// <summary>
		/// Add given numbers.
		/// </summary>
		/// <param name="left">Left number.</param>
		/// <param name="right">Right number.</param>
		/// <returns>left + right</returns>
		public int AddLiteral(int left, int right)
		{
			lock( logic )
			{
				return logic.AddLiteral(left, right);
			}
		}

		/// <summary>
		/// Add given numbers.
		/// </summary>
		/// <param name="leftAndRight">Numbers to add.</param>
		/// <returns>Left + Right in Sum</returns>
		public ByValStruct AddStruct(ByValStruct leftAndRight)
		{
			lock( logic )
			{
				return logic.AddStruct(leftAndRight);
			}
		}
	}
}
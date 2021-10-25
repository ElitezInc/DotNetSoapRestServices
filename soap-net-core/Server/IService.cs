using System;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace Server 
{
	/// <summary>
	/// Structure for testing pass-by-value calls.
	/// </summary>
	[DataContract]
	public class ByValStruct
	{
		/// <summary>
		/// Left number.
		/// </summary>
		[DataMember]
		public int Left{ get; set; }

		/// <summary>
		/// Right number.
		/// </summary>
		/// <value></value>
		[DataMember]
		public int Right{ get; set; }

		/// <summary>
		/// Left + Right
		/// </summary>
		[DataMember]
		public int Sum{ get; set; }
	}

	/// <summary>
	/// Service contract.
	/// </summary>
	[ServiceContract]
	public interface IService
	{
		/// <summary>
		/// Add given numbers.
		/// </summary>
		/// <param name="left">Left number.</param>
		/// <param name="right">Right number.</param>
		/// <returns>left + right</returns>
		[OperationContract]
		int AddLiteral(int left, int right);

		/// <summary>
		/// Add given numbers.
		/// </summary>
		/// <param name="leftAndRight">Numbers to add.</param>
		/// <returns>Left + Right in Sum</returns>
		[OperationContract]
		ByValStruct AddStruct(ByValStruct leftAndRight);
	}
}
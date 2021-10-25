using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;


namespace Server
{
	/// <summary>
	/// Service. Class must be marked public, otherwise ASP.NET core runtime will not find it.
	/// </summary>
	[Route("/service")] [ApiController]
	public class ServiceController : ControllerBase
	{
		/// <summary>
		/// Service logic. Use a singleton instance, since controller is instance-per-request.
		/// </summary>
		private static readonly ServiceLogic logic = new ServiceLogic();

		/// <summary>
		/// Add given numbers.
		/// </summary>
		/// <param name="left">Left number.</param>
		/// <param name="right">Right number.</param>
		/// <returns>left + right</returns>
		[HttpGet]
		[Route("AddLiteral")]
		public ActionResult<int> AddLiteral([FromQuery] int left, [FromQuery] int right)
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
		[HttpPost]
		[Route("AddStruct")]
		public ActionResult<ByValStruct> AddStruct([FromBody] ByValStruct leftAndRight)
		{
			lock( logic )
			{
				return logic.AddStruct(leftAndRight);
			}
		}
	}
}
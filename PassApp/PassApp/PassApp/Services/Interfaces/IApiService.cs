using System;
using System.Threading.Tasks;
using PassApp.Models;
using Refit;

namespace PassApp.Services.Interfaces
{
	public interface IApiService
	{
		[Get("/?char={ch}")]
		Task<ApiResponse<PassResponse>> GetPassword([Query]bool num, bool ch, [Query]bool caps, [Query]int len);
	}
}


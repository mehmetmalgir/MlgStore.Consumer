using MlgStore.WebUI.Models.Dtos;
using System.Collections.Generic;

namespace MlgStore.WebUI.Areas.Admin.Models
{
	public class ModelForHomePage
	{

		public List<ApiOrderDto> Orders { get; set; }
		public List<ApiComplaintsDto> Complaints { get; set; }


	}
}

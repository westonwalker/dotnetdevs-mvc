using dotnetdevs.Models;

namespace dotnetdevs.ViewModels
{
	public class DevelopersIndex : BaseViewModel
	{
		public List<Developer> Developers { get; set; } = new List<Developer>();
	}
}

using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using PhotoEditor.Core.Services;
using PhotoEditor.Core.Services.Implementation;
using PhotoEditor.Core.ViewModels;

namespace PhotoEditor.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			Mvx.LazyConstructAndRegisterSingleton<ISoapServiceProxy, SoapServiceProxy>();
			RegisterAppStart<FirstViewModel>();
		}
	}
}

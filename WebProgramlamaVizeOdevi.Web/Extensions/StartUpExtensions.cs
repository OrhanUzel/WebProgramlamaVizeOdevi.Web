using Microsoft.AspNetCore.Identity;
using WebProgramlamaVizeOdevi.Web.Localization;
using WebProgramlamaVizeOdevi.Web.Models;

namespace WebProgramlamaVizeOdevi.Web.Extensions
{
    public static  class StartUpExtensions
    {// program cs yerine buraya yazıyoruz karışıklık azalması için 
      //program cs e fonksiyonu eklenmesi şartıyla tabii ki 
        //localization  gibi işlemler burada yapılıyor
        public static void AddIdentityWithExt(this IServiceCollection services)
        {

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromMinutes(30);//şifre sıfırlama linkimizin ömrü 30 dakika olacak
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //kitlenme mekanizmasını opsiyonel olaraak değiştirme
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);//3 dakikalık bir kitlenme olacak hesap kitlenirse
                options.Lockout.MaxFailedAccessAttempts = 3;//başarısız deneme girişşi defaultta 5 idi 

            }).AddErrorDescriber<LocalizationIdentityErrorDescriber>()//türkçe hata kodları eklendi
                                                                      //şifre sıfırlaama e maili göndermek için kullanıyoruzz   
            .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


        }






    }
}

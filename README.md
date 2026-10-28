\# NTierArchitecture



Öğrenci, sınıf, ders, öğretmen, sınav ve devamsızlık kayıtlarını yönetmek için geliştirilmiş, SQL Server kullanan katmanlı bir Windows Forms uygulaması.



\## Teknolojiler



\- .NET 10

\- Windows Forms

\- Entity Framework Core 10

\- SQL Server

\- FluentValidation



\## Proje yapısı



| Proje | Sorumluluk |

|---|---|

| `NTierArchitecture.Domain` | Alan varlıkları ve temel entity modeli |

| `NTierArchitecture.DataAccsess` | `AppDbContext`, Entity Framework Core ve repository sınıfları |

| `NTierArchitecture.Business` | İş servisleri ve FluentValidation doğrulamaları |

| `NTierArchitecture.Presentation` | Windows Forms arayüzü, uygulama başlangıcı ve bağımlılık kayıtları |



> `DataAccsess` proje adı depoda bu şekilde yazılmıştır. Komutlarda mevcut adı kullanın.



\## Gereksinimler



\- Windows işletim sistemi

\- .NET 10 SDK

\- SQL Server

\- Veritabanına erişim izni olan bir Windows hesabı



\## İlk kurulum



\### 1. Depoyu klonlayın



```powershell

git clone https://github.com/MuhammedHakan/NTierArchitecture.git

cd NTierArchitecture

```



Depo zaten bilgisayarınızdaysa PowerShell'de depo klasörüne geçin:



```powershell

cd C:\\Projects\\NTierArchitecture

```



\### 2. Bağımlılıkları yükleyin



```powershell

dotnet restore .\\NTierArchitecture.slnx

```



\### 3. SQL Server bağlantısını yapılandırın



`NTierArchitecture.Presentation\\appsettings.json` dosyasındaki `DefaultConnection` değerini kendi SQL Server kurulumunuza göre düzenleyin.



Mevcut varsayılan ayar:



```json

{

&#x20; "ConnectionStrings": {

&#x20;   "DefaultConnection": "Server=.\\\\MSSQLSERVER02;Database=NTierArchitectureDb;Integrated Security=True;Trust Server Certificate=True;"

&#x20; }

}

```



Bu ayar `.\\MSSQLSERVER02` adlı SQL Server örneğini ve Windows kimlik doğrulamasını kullanır. Farklı bir sunucu veya örnek kullanıyorsanız `Server` değerini güncelleyin.



\### 4. Veritabanını hazırlayın



Uygulama başlangıçta veritabanı migration’larını otomatik uygulamaz. Veritabanı şemasını uygulamayı çalıştırmadan önce oluşturun veya güncelleyin.



EF Core komut satırı aracı yüklü değilse:



```powershell

dotnet tool install --global dotnet-ef --version 10.0.12

```



Migration’ların mevcut olup olmadığını kontrol edin:



```powershell

$project = ".\\NTierArchitecture.DataAccsess\\NTierArchitecture.DataAccsess.csproj"

$startup = ".\\NTierArchitecture.Presentation\\NTierArchitecture.Presentation.csproj"



dotnet ef migrations list --project $project --startup-project $startup --context AppDbContext

```



Migration’lar mevcutsa veritabanına uygulayın:



```powershell

dotnet ef database update --project $project --startup-project $startup --context AppDbContext

```



Projede henüz migration yoksa aşağıdaki komutu bir kez çalıştırın, ardından `database update` komutunu çalıştırın:



```powershell

dotnet ef migrations add InitialCreate --project $project --startup-project $startup --context AppDbContext --output-dir Migrations

```



\### 5. Uygulamayı derleyip çalıştırın



```powershell

dotnet build .\\NTierArchitecture.slnx

dotnet run --project .\\NTierArchitecture.Presentation\\NTierArchitecture.Presentation.csproj

```



Visual Studio ile çalıştırmak için `NTierArchitecture.slnx` dosyasını açın, `NTierArchitecture.Presentation` projesini başlangıç projesi olarak seçin ve uygulamayı başlatın.



\## Yönetilen kayıt türleri



\- \*\*Sınıf (Class)\*\* ve öğrenciler

\- \*\*Ders (Lesson)\*\* ve öğretmenler

\- \*\*Sınav (Exam)\*\* — öğrenci ve ders ile ilişkilidir

\- \*\*Devamsızlık (Discontinuity)\*\* — öğrenci ile ilişkilidir



\## Yapılandırma notları



\- Veritabanı bağlantısı `NTierArchitecture.Presentation\\appsettings.json` dosyasından okunur.

\- `appsettings.json` derleme çıktısına kopyalanır.

\- SQL Server bağlantı hatasında sunucu/örnek adının ve Windows hesabının veritabanı izinlerinin doğru olduğunu kontrol edin.

\- Uygulama Windows Forms kullandığından Windows üzerinde çalıştırılmalıdır.


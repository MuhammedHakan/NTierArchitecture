# 🏫 NTierArchitecture

![.NET](https://shields.io)
![Windows Forms](https://shields.io)
![EF Core](https://shields.io)
![SQL Server](https://shields.io)

SQL Server tabanlı, katmanlı mimari (N-Tier Architecture) prensiplerine uygun olarak geliştirilmiş modern bir **Öğrenci ve Akademik Kayıt Yönetim Sistemi** Windows Forms uygulamasıdır.

---

## 🚀 Teknolojiler ve Araçlar

Proje geliştirilirken aşağıdaki güncel teknolojiler ve kütüphaneler kullanılmıştır:

* **Framework:** .NET 10 (Windows Forms)
* **ORM:** Entity Framework Core 10
* **Veritabanı:** Microsoft SQL Server
* **Doğrulama:** FluentValidation (İş kuralları ve veri doğrulamaları için)

---

## 📂 Proje Yapısı

Uygulama, sorumlulukların net bir şekilde ayrılması amacıyla **4 ana katman** halinde tasarlanmıştır:

| Proje / Katman | Sorumluluk alanı |
| :--- | :--- |
| 🔹 `NTierArchitecture.Domain` | Alan varlıkları (Entities), temel iş modelleri ve veritabanı şeması. |
| 🔹 `NTierArchitecture.DataAccsess` | `AppDbContext`, EF Core yapılandırmaları ve veri erişim (Repository) sınıfları. |
| 🔹 `NTierArchitecture.Business` | İş servisleri (Business Services), mantıksal kurallar ve FluentValidation doğrulamaları. |
| 🔹 `NTierArchitecture.Presentation` | Windows Forms arayüz bileşenleri, uygulama başlangıcı ve IoC/DI bağımlılık kayıtları. |
| 🔹 `NTierArchitecture.Presentation.API` | ASP.NET Core Web API katmanı; Swagger arayüzü ve CRUD endpoint'leri. |

> ⚠️ **Not:** Depo içerisinde veri erişim katmanının adı imla hatasıyla `DataAccsess` olarak adlandırılmıştır. Terminal komutlarında bu adı aynen kullanmaya dikkat edin.

---

## 🛠️ Gereksinimler

Uygulamayı yerel ortamınızda ayağa kaldırmak için aşağıdaki bileşenlerin yüklü olması gerekir:

* 💻 **İşletim Sistemi:** Windows (Windows Forms bağımlılığı nedeniyle)
* 💿 **SDK:** [.NET 10 SDK](https://microsoft.com)
* 🛢️ **Veritabanı:** Microsoft SQL Server (LocalDB veya Express/Standart sürüm)
* 🔐 **Yetkilendirme:** SQL Server üzerinde veritabanı oluşturma ve düzenleme yetkisine sahip bir Windows hesabı

---

## 💻 İlk Kurulum ve Çalıştırma

### 1. Projeyi Klonlayın
Öncelikle depoyu bilgisayarınıza indirin veya PowerShell üzerinde mevcut klasörünüze geçiş yapın:

```powershell
# Depoyu klonlamak için:
git clone https://github.com/MuhammedHakan/NTierArchitecture.git
cd NTierArchitecture

# Depo zaten bilgisayarınızdaysa:
cd C:\Projects\NTierArchitecture
```

### 2. Bağımlılıkları Yükleyin
NuGet paketlerini ve proje bağımlılıklarını geri yüklemek için çözüm dosyasını restore edin:

```powershell
dotnet restore .\NTierArchitecture.slnx
```

### 3. SQL Server Bağlantısını Yapılandırın
`NTierArchitecture.Presentation\appsettings.json` dosyasını açarak `DefaultConnection` değerini kendi yerel SQL Server ayarlarınıza göre güncelleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\MSSQLSERVER02;Database=NTierArchitectureDb;Integrated Security=True;Trust Server Certificate=True;"
  }
}
```
* *`Server` parametresini kendi SQL örneğinize (`.\\SQLEXPRESS`, `(localdb)\\MSSQLLocalDB` vb.) göre değiştirmeyi unutmayın.*

### 4. Veritabanı Geçişlerini (Migrations) Uygulayın
Uygulama ilk açılışta veritabanını otomatik olarak oluşturmaz. Şemayı hazırlamak için aşağıdaki adımları sırasıyla izleyin.

Eğer bilgisayarınızda **Entity Framework Core CLI** aracı yüklü değilse yükleyin:
```powershell
dotnet tool install --global dotnet-ef --version 10.0.12
```

Projedeki mevcut migration listesini doğrulamak için (isteğe bağlı):
```powershell
$project = ".\NTierArchitecture.DataAccsess\NTierArchitecture.DataAccsess.csproj"
$startup = ".\NTierArchitecture.Presentation\NTierArchitecture.Presentation.csproj"

dotnet ef migrations list --project project --startup-project startup --context AppDbContext
```

**Veritabanını oluşturmak ve şemayı basmak için:**
```powershell
dotnet ef database update --project project --startup-project startup --context AppDbContext
```

*Eğer projede henüz hiç hazır migration bulunmuyorsa, önce yeni bir geçiş oluşturup ardından yukarıdaki `update` komutunu çalıştırın:*
```powershell
dotnet ef migrations add InitialCreate --project project --startup-project startup --context AppDbContext --output-dir Migrations
```

### 5. Uygulamayı Derleyin ve Çalıştırın
Her şey hazır olduğunda projeyi CLI üzerinden derleyip başlatabilirsiniz:

```powershell
dotnet build .\NTierArchitecture.slnx
dotnet run --project .\NTierArchitecture.Presentation\NTierArchitecture.Presentation.csproj
```

> 💡 **Visual Studio Kullanıcıları:** `NTierArchitecture.slnx` dosyasını çift tıklayarak açabilir, `NTierArchitecture.Presentation` projesine sağ tıklayıp **"Set as Startup Project"** dedikten sonra `F5` tuşu ile uygulamayı hızlıca başlatabilirler.

### 6. REST API'yi (Swagger) Çalıştırın
Windows Forms arayüzüne ek olarak projede bir ASP.NET Core Web API katmanı bulunur. API'yi başlatmak için:

```powershell
dotnet run --project .\NTierArchitecture.Presentation.API\NTierArchitecture.Presentation.API.csproj
```

Uygulama açıldığında tarayıcı otomatik olarak Swagger arayüzünü açar:

```text
http://localhost:5199/swagger
```

Swagger üzerinden sınıf, ders, öğrenci, öğretmen, sınav ve devamsızlık modüllerinin tüm CRUD endpoint'lerini test edebilirsiniz. OpenAPI dokümanı ayrıca `/openapi/v1.json` adresinde (Development ortamında) yayınlanır.

---

## 📊 Yönetilen Kayıt Türleri ve İlişkiler

Uygulama içerisindeki veri modelleri ve işlevsel modüller şu şekildedir:

* **Sınıf (Class):** Sınıf tanımlamaları ve bu sınıflara bağlı öğrenciler.
* **Ders (Lesson):** Müfredat dersleri ve dersleri veren öğretmen eşleştirmeleri.
* **Sınav (Exam):** Öğrenci ve dersler ile doğrudan ilişkili not ve sınav kayıtları.
* **Devamsızlık (Discontinuity):** Öğrencilerin devamsızlık durumlarının takibi.

---

## 📝 Önemli Yapılandırma Notları

* **Bağlantı Yönetimi:** Uygulama çalışma zamanında veritabanı adresini `NTierArchitecture.Presentation\appsettings.json` dosyasından okur. Bu dosya derleme esnasında çıktı (`bin/`) klasörüne otomatik kopyalanmaktadır.
* **Bağlantı Hataları:** Olası bir SQL bağlantı hatasında, Windows kullanıcınızın SQL Server üzerinde `sysadmin` veya `dbcreator` yetkisine sahip olduğundan ve sunucu adının doğruluğundan emin olun.
* **Platform Kısıtlaması:** Arayüz motoru olarak yerel Windows kütüphanelerini kullanan Windows Forms tercih edildiği için proje yalnızca **Windows işletim sistemlerinde** çalıştırılabilir.

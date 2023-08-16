Library Application
https://github.com/fikaya/LibraryApplication
![image](https://github.com/fikaya/CaseLibraryApplication/assets/51996603/01ef56d7-9a7a-46f2-b620-66b87aa98133)
Uygulama içerisinde toplam 8 tane ana tablomuz var. Projeyi daha iyi anlamak adına bunları tek tek açıklamak yerinde olacaktır.
Her kullanıcı birden fazla kitabı kütüphaneden temin edebilirken bir kitabı da, birden fazla kullanıcı kütüphaneden temin edebilir. 
Onun için Reservations isminde bir tablomuz mevcut. Burada Çoka-Çoka ilişki sağlamış olduk.
Her kitabın yazarı tek olmayabilir düşüncesi ile yine bir ara tablo inşa ederek Çoka-Çoka ilişki sağlamış olduk.(AuthorBooks)
Bir kitabın bir yayınevi olabilir düşüncesi ile Publishers Tablosu ile Books Tablosu arasında Bire-Çok bir ilişki mevcut. Burada bir nokta kafa karıştırıcı olabilir.
Mesela Suç Ve Ceza hem Yapı Kredi hem de İş Bankası tarafından basılıyor diyelim. Burada aklımıza şu soru geliyor. Bunlar aynı kitap değil mi? Evet, özünde aynı ama 
farklı değerlendireceğiz. Buna benzer bir ayrımı başka bir tablo üzerinde yaptığımı da eklemek isterim.
Son olarak Reservations-BookEditionNumbers-Books-EditionNumbers tabloları arasındaki ilişkiden bahsetmek istiyorum. Açık konuşmak gerekirse proje tasarım aşamasında beni 
en çok zorlayan taraf oldu. Bir kitabın birden çok basım numarası olabilirken bir basım numarası da birden fazla kitabın olabilir. Burası kolay bir denklem. Sonuçta Çoka-Çok
bir ilişki kuracağız. Ama rezervasyonları yaparken Books tablosu üzerinden mi yoksa BookEditionNumbers tablosu üzerinden mi ilerlemenin daha doğru olacağına cevap bulma konusunda
zorlandım ve en son şöyle bir yapı kurdum.  Bir kitap birden fazla basım numarasına sahip olabilir. Örnek verirsek Yapı Kredi Yayınlarının Suç ve Ceza kitabının 10 adet basım
numarası var ve her basım numarasından 10 kitap olduğunu hayal edersek Rezervasyon işlemlerinin tekil bir kitap üzerinden değil alt kırımlıları olan basım numaraları üzerinden 
gitmenin doğru olacağı ortaya çıkmış oluyor.  

// Test JavaScript dosyası
function hesapla(x, y) {
    // Basit toplama işlemi
    return x + y;
}

// Obje tanımı
const kisi = {
    ad: "Ahmet",
    soyad: "Yılmaz",
    tamAd: function() {
        return this.ad + " " + this.soyad;
    }
};

// Örnek kullanım
console.log("Toplam: " + hesapla(5, 10));
console.log("Kişi: " + kisi.tamAd()); 
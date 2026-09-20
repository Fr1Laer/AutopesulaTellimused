## Autopesula Tellimused

Projekt kujutab endast C# ja WPF-põhist töölauarakendust autopesula tellimuste haldamiseks. Rakendus võimaldab sisestada uusi tellimusi, muuta olemasolevaid andmeid ning kustutada vajaduse korral valitud kirjeid

---

## Rakenduse kirjeldus

Rakendus pakub lihtsat liidest pesula töö korraldamiseks. Kasutaja sisestab sõiduki registreerimisnumbri, valib sõiduki tüübi ning soovitud pesuprogrammi. Süsteem arvutab automaatselt teenuse hinna ja kestuse ning kuvab kõik andmed koondtabelis koos üldise statistikaga

---

## Tehniline ülevaade

`AutopesulaTellimused.Core`: Klassiraamatukogu, mis sisaldab andmemudeleid ja äriloogikat.

`AutopesulaTellimused.WpfApp`: WPF-rakendus kasutajaliidese ja sündmuste töötlemiseks.

---

## Kuidas programmiga töötada

- Sisesta sõiduki registreerimisnumber (2 kuni 10 märki)

- Vali rippmenüüst sõiduki liik (Sedan, SUV, Van)

- Vali rippmenüüst pesuprogramm (Express, Standard, Premium)

- Uue kirje lisamiseks klõpsa nupul **Lisa tellimus**

- Olemasoleva kirje muutmiseks vali see tabelist, tee vajalikud muudatused väljadel ja klõpsa nupul **Muuda valitud**

- Kirje eemaldamiseks vali see tabelist ning klõpsa nupul **Kustuta valitud**

---

## Veastsenaariumid ja teated

### Valed sisendandmed:

**Tegevus**: Kasutaja jätab reg-numbri sisestamata või sisestab ainult ühe tähe



**Tegevus**: Reg-number on sisestatud, kuid sõiduki liik on valimata



**Tegevus**: Kasutaja üritab lisada teist korda auto samasuguse numbriga 123ABC**



**Tegevus**: Kasutaja üritab lisada teist korda auto samasuguse numbriga 123ABC**



**Tegevus**: Kasutaja vajutab nuppu "Kustuta valitud", ilma et oleks tabelist ühtegi rida valinud.




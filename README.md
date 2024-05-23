<h1>Atomreaktor Szimulátor</h1>
<br>
<p>Az Atomreaktor Szimulátor program célja egy atomreaktor működésének szimulálása, beleértve a reaktor beindítását, leállítását, a generált energia mennyiségének és a reaktor hőmérsékletének megjelenítését, valamint a reaktor hűtését. A program véletlenszerűen generál adatokat a szimuláció során, hogy a felhasználó valószerű élményt kapjon.</p>

<h2>Menüpontok</h2>
<br>
<ul>
<li>1. Beindítás: Elindítja az atomreaktort.</li>
<li>2. Leállítás: Leállítja az atomreaktort (biztonságos hőmérséklet esetén).</li>
<li>3. Generált energia mennyiség: Megjeleníti a reaktor által termelt energiát gigawattban.</li>
<li>4. Hőfok: Megjeleníti a reaktor hőmérsékletét.</li>
<li>5. Hűtővíz beengedése: Lehűti a reaktort 40 fokra.</li>
</ul>
<br>
<h2>Működés</h2>
<br>
<ul>
<li>A program véletlenszerűen generálja a reaktor hőmérsékletét 40 és 100 fok között.</li>
<li>A program véletlenszerűen generálja a reaktor által termelt energiát gigawattban, amely az előző értéknél mindig nagyobb.</li>
<li>A reaktor csak akkor állítható le, ha a hőmérséklete 70 fok alatt van.</li>
<li>Ha a reaktor hőmérséklete 70 fok felett van, a leállítási kísérlet sikertelen lesz, és a felhasználó figyelmeztetést kap, hogy hűtenie kell a rendszert.</li>
<li>Ha a felhasználó nem hűti le a reaktort, és más menüpontra lép, a reaktor felrobban.</li>
</ul>
<br>
<h2>Használati Példa</h2>
<br>
<ul>
<li>Indítsa el a reaktort a "Beindítás" menüpont kiválasztásával. A program néhány másodpercig tölt.</li>
<li>A program megjeleníti a reaktor hőmérsékletét (pl. 78 fok) és a generált energia mennyiségét (pl. 5 GW).</li>
<li>Ha a reaktor hőmérséklete túl magas, például 78 fok, a leállítási kísérlet figyelmeztetést fog eredményezni, hogy a reaktort hűteni kell.</li>
<li>Hűtse le a reaktort a "Hűtővíz beengedése" menüpont kiválasztásával, amely lehűti a reaktort 40 fokra.</li>
<li>Most már leállíthatja a reaktort a "Leállítás" menüpont kiválasztásával.</li>
</ul>
<br>
<h2>Fontos Megjegyzések</h2>
<ul>
<li>A reaktort csak akkor lehet biztonságosan leállítani, ha a hőmérséklete 70 fok alatti.</li>
<li>A reaktor hűtését minden esetben el kell végezni, ha a hőmérséklet 70 fok felett van, különben a reaktor felrobban.</li>
<li>Minden alkalommal, amikor a generált energia mennyiségét kérdezi le, az új érték az előzőnél nagyobb lesz.</li>
</ul>

<p>Rajna Torda Imre (rajnat@kkszki.hu)</p>
<p>Ujvári László Botond (ujvaril@kkszki.hu)</p>

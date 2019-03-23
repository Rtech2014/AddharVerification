
const loc = document.querySelectorAll('#Location');
let lat;
let long;
function latlong(doc) {

    lat = doc.data().Latitude;
    long = doc.data().Longitude;

    document.getElementById("lat").innerHTML = lat;
    document.getElementById("long").innerHTML = long;

}
function openloc() {
    window.open("https://www.google.com/maps?ll=" + lat + "," + long);
}


db.collection('Location').get().then((snapshot) => {
    snapshot.docs.forEach(doc => {
        latlong(doc);
    });
});
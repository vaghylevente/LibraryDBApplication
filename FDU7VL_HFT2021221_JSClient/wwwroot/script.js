let students = [];

fetch('http://localhost:20621/student')
    .then(x => x.json())
    .then(y => {
        students = y;
        console.log(students);
        display();
    });

function display() {
    students.forEach(t => {
        /*document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.studentID + "</td><td>" + t.name + "</td><td>" + t.class + "</td><tr>";
        /*document.getElementById('resultarea').innerHTML +=
            "<tr>" + 
            "<td>" + t.studentID + "</td>" +
            "<td>" + t.name + "</td>" +
            "<td>" + t.class + "</td>" +
            "</tr> ";*/
        document.getElementById('resultarea').innerHTML += `
            <tr>
            <td>${t.studentID}</td>
            <td>${t.name}</td>
            <td>${t.class}</td>
            </tr>`
    })
}
let students = [];
let connection = null;
let IdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:20621/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StudentCreated", (user, message) => {
        getdata();
    });
    connection.on("StudentDeleted", (user, message) => {
        getdata();
    });
    connection.on("StudentUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}


async function getdata() {
    await fetch('http://localhost:20621/student')
        .then(x => x.json())
        .then(y => {
            students = y;
            console.log(students);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
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
            <td>${t.studentClass}</td>
            <td>
            <button type="button" onclick="remove(${t.studentID})">Delete</button>
            <button type="button" onclick="showupdate(${t.studentID})">Update</button>
            </td>
            </tr>`
    })
}

function showupdate(id) {
    document.getElementById('studentnametoupdate').value = students.find(t => t['studentID'] == id)['name'];
    document.getElementById('studentclasstoupdate').value = students.find(t => t['studentID'] == id)['studentClass'];
    document.getElementById('updateformdiv').style.display = 'inline';
    IdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:20621/student/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let studentname = document.getElementById('studentname').value;
    let studentclass = document.getElementById('studentclass').value;
    fetch('http://localhost:20621/student', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: studentname, studentClass: studentclass }
        ),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let studentname = document.getElementById('studentnametoupdate').value;
    let studentclass = document.getElementById('studentclasstoupdate').value;
    fetch('http://localhost:20621/student', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: studentname, studentClass: studentclass, studentID: IdToUpdate }
        ),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
fetch('http://localhost:20621/student')
    .then(x => x.json())
    .then(y => console.log(y));
const fetchProps = {
    method: "GET",
    headers: {
        "Content-Type": "application/json"
    }
}

const myRequest = new Request("/api/books", fetchProps);
fetch(myRequest)
    .then((response) => {
        response.json().then((response) => {
            buildList(response);
        })
})

function buildList(response) {
    const bookList = document.getElementById("BookList");
    for (book in response) {
        const bookEntry = document.createElement("li");
        bookEntry.Id = response[book].Id;
        bookEntry.innerHTML = response[book].Title;
        bookList.appendChild(bookEntry)
    }
}
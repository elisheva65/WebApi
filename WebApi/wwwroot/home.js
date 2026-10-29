


const addUserToServer = async () => {
    const name = document.querySelector("#name").value
    const lastName = document.querySelector("#lastName").value
    const password = document.querySelector("#password").value
    const email = document.querySelector("#email").value
    const user = { email: email, password: password, name: name, lastName: lastName   }
    try {
        const response = await fetch('api/Users', {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(user)

        })
        if (!response.ok)
            throw new Error("error adding details")
        else alert("נרשמת")
    }
    catch (error) {
        alert(error.message)
    }
}
const login = async () => {

    const password = document.querySelector("#password").value
    const email = document.querySelector("#email").value
    const userLogin = { email: email, password: password }
    try {
        const response = await fetch('api/Users/login', {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(userLogin)

        })
        if (!response.ok)
            throw new Error("error finding user")
        else {
            const user = await response.json();
            sessionStorage.setItem("user", JSON.stringify(user))
            alert("התחברת")
        }

    }
    catch (error) {
        alert(error.message)
    }
}

const strongPassword = async () => {
    const password = document.querySelector("#password").value
    
    try {
        const response = await fetch('api/Password', {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(password)

        })
        if (!response.ok)
            throw new Error("error in password")
        else {
            alert("Dsds")
            const result = await response.json()
            document.querySelector("#progress").value = result
        }
    }
        catch (error) {
            alert(error.message)
        }
    
}

                                                                                     
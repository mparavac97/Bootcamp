import React from 'react';

class Register extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            user : {  },
            listOfUsers : []
        }

        this.addUserOnClick = this.addUserOnClick.bind(this);
        this.addUserToListOnClick = this.addUserToListOnClick.bind(this);
    }

    addUserOnClick() { 
        this.setState(prevState => ({
            user: {
                ...prevState.user,
                name: document.getElementById("name").value,
                surname : document.getElementById("surname").value,
                address : document.getElementById("address").value,
                email: document.getElementById("email").value,
                username : document.getElementById("username").value,
                password : document.getElementById("password").value
            }
        }))
        console.log(this.state.user);
    }

    addUserToListOnClick() {
        this.setState(prevState => ({
            listOfUsers: [...prevState.listOfUsers, this.state.user]
        }));
        console.log(this.state.listOfUsers);
    }

    render() {
        return (
            <div>
                <button onClick = {() => {this.addUserOnClick(); this.addUserToListOnClick();}}>
                    Register (class)
                </button>
            </div>
        )
    }
}

export default Register;
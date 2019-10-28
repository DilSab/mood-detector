import React, { Component } from 'react';

export class LogIn extends Component {
    displayName = LogIn.name

    render() {
        return (
            <div>
                <h1>Please login:</h1>
                <label>Username: </label> <input type="text" />
                <label>Password: </label> <input type="text" />
                <button>Login</button>
            </div>
        );
    }
}
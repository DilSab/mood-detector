import React, { Component } from 'react';

export class LogOut extends Component {
    displayName = LogOut.name;

    render() {
        return (
            <div>
                <h1>Here nothing will be displayed</h1>
                <p>cause user will be loged out</p>
                <p>and app redirected to log in page</p>
            </div>
        )
    }
}
import React, { Component } from 'react';

export class MyProfileAdmin extends Component {
    displayName = MyProfileAdmin.name;

    render() {
        return (
            <div>
                <h1>My profile admin window</h1>
                <p>here admin will see their info:</p>
                <ul>
                    <li>name</li>
                    <li>surname</li>
                    <li>username</li>
                    <li>can change their password???</li>
                    <li>view all teachers???</li>
                    <li>some other info...</li>
                </ul>
            </div>
        )
    }
}
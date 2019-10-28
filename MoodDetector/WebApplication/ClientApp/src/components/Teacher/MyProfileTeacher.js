import React, { Component } from 'react';

export class MyProfileTeacher extends Component {
    displayName = MyProfileTeacher.name;

    render() {
        return (
            <div>
                <h1>My profile teacher window</h1>
                <p>here teacher will see their info:</p>
                <ul>
                    <li>name</li>
                    <li>surname</li>
                    <li>username</li>
                    <li>can change their password???</li>
                    <li>some classes assigned to him???</li>
                    <li>some other info...</li>
                </ul>
            </div>
        )
    }
}
import React, { Component } from 'react';

export class SendInfo extends Component {
    displayName = SendInfo.name;

    render() {
        return (
            <div>
                <h1>Send info to teacher window</h1>
                <p>here admin can send some info to teachers, they will see it in important info tab</p>
            </div>
        )
    }
}
import React, { Component } from 'react';

export class ImportantInfo extends Component {
    displayName = ImportantInfo.name;

    render() {
        return (
            <div>
                <h1>Important info window</h1>
                <p>here teacher will see important info sent by admin</p>
            </div>
        )
    }
}
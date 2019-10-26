import React, { Component } from 'react';

export class AffectivaTest extends Component {
    displayName = AffectivaTest.name

    sayHello() {
        alert(document.getElementById('file').files.item(0).name);
    }

    render() {
        return (
            <div>
                <h1>Upload photo:</h1>
                <input id="file" type="file" />
                <input type="submit" onClick={this.sayHello} />
            </div>
        );
    }
}
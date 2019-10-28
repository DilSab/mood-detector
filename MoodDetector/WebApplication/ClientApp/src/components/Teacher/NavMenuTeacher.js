import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import '../NavMenu.css';

export class NavMenuTeacher extends Component {
    displayName = NavMenuTeacher.name

    render() {
        return (
            <Navbar inverse fixedTop fluid collapseOnSelect>
                <Navbar.Header>
                    <Navbar.Brand>
                        <Link to={'/about'}>Mood Detector</Link>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav>
                        <LinkContainer to={'/importantInfo'} exact>
                            <NavItem>
                                <Glyphicon glyph='flash' /> Important Info
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/newSession'} exact>
                            <NavItem>
                                <Glyphicon glyph='plus' /> New Session
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/viewSessions'} exact>
                            <NavItem>
                                <Glyphicon glyph='th-list' /> View Sessions
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/learnings'} exact>
                            <NavItem>
                                <Glyphicon glyph='education' /> Learnings
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/myProfileTeacher'} exact>
                            <NavItem>
                                <Glyphicon glyph='user' /> My Profile
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/logOut'} exact>
                            <NavItem>
                                <Glyphicon glyph='log-out' /> Log Out
                            </NavItem>
                        </LinkContainer>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}

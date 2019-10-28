import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenuWelcome } from './Welcome/NavMenuWelcome';
import { NavMenuTeacher } from './Teacher/NavMenuTeacher';
import { NavMenuAdmin } from './Admin/NavMenuAdmin';

export class Layout extends Component {
  displayName = Layout.name

  render() {
    return (
      <Grid fluid>
        <Row>
          <Col sm={3}>
            <NavMenuWelcome />
          </Col>
          <Col sm={9}>
            {this.props.children}
          </Col>
        </Row>
      </Grid>
    );
  }
}

import React, { Component, useState, useEffect } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import Swagger from './components/Swagger';
import './custom.css';

export class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props)
    }

    render() {
        return (
            <Swagger />

            //<Layout>
            //    <Routes>
            //        {AppRoutes.map((route, index) => {
            //            const { element, ...rest } = route;
            //            return <Route key={index} {...rest} element={element} />;
            //        })}
            //    </Routes>
            //</Layout>
        );
    }
}

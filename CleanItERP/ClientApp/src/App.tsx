import * as React from "react";
import "./App.scss";
import { Footer } from "./Navigation/Footer";
import { Header } from "./Navigation/Header";

export class App extends React.Component{

    render(){
        return (
            <div className="app">
                <Header />
                <div className="main">
                    main
                </div>
                <Footer />
            </div>
        )
    }
}
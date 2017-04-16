import * as React from 'react';
import { Link } from 'react-router-dom';


export const Header = () => {

    return (

        <header className="mdl-layout__header">
            <div className="mdl-layout__header-row">
                <span className="mdl-layout-title">
                    <Link to="/" className="mdl-navigation__link"><h3>RestaurantApp</h3></Link>
                </span>
                <div className="mdl-layout-spacer"></div>
                <nav className="mdl-navigation">

                    <Link to="/restaurants" className="mdl-navigation__link">Restaurants</Link>
                    <a href="badges.html" className="mdl-navigation__link">User</a>
                    <Link to="/profile" className="mdl-navigation__link"></Link>
                </nav>
            </div>
        </header>

    )

}
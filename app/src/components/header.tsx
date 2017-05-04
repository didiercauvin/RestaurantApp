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
                <button id="demo-menu-lower-left"
                    className="mdl-button mdl-js-button">
                    Restaurants...
                </button>
                <nav className="mdl-navigation">
                    <ul className="mdl-menu mdl-menu--bottom-left mdl-js-menu mdl-js-ripple-effect"
                        htmlFor="demo-menu-lower-left">

                        <li className="mdl-menu__item">
                            <Link to="/restaurants">Ajouter</Link>
                        </li>
                        <li className="mdl-menu__item">
                            <Link to="/restaurants">Liste</Link>
                        </li>
                    </ul>
                </nav>
            </div>
        </header>

    )

}
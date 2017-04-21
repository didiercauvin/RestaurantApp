import * as React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Input, Select } from '../share/elements';

interface AddRestaurantState {
    name: string;
    number_street: string;
    adress: string;
    postalCode: string;
    city: string;
    takeOut: boolean;
    cuisine: Array<string>;
}

interface RestaurantProps {
    restos?: string[];
}

interface DispatchProps {
    onSubmit?: (restaurant:AddRestaurantState) => void;
}

type RestoProps = RestaurantProps & DispatchProps;

class AddRestaurant extends React.Component<RestoProps, AddRestaurantState>{

    constructor(props: RestoProps) {
        super(props);
        this.state = {
            name: '',
            takeOut: false,
            number_street: '',
            adress: '',
            postalCode: '',
            city: '',
            cuisine: ["coucou", "salut"]
        };
    }


    componentDidMount() {
        //tricks pour typescript pour register dans gmtl
        var windowany: any = window;
        windowany.componentHandler.upgradeDom();
    }

    render() {
        const handleInputChange = (e: any) => {
            const target = e.target;
            const value = target.type === 'checkbox' ? target.checked : target.value;
            const name = target.id;
            this.setState({
                [name]: value
            });
        }

        const handleComboboxChange = (e: any) => {
            
        }

        const handleSubmit = (e:any) => {
            var restaurant = this.state;
            this.props.onSubmit(restaurant);
        }


        return (
            <div>
                <Input name="Nom du restaurant" id="name" value={this.state.name} onchange={handleInputChange} />
                <br />
                <Input name="N° de rue" id="number_street" value={this.state.number_street} onchange={handleInputChange} />
                <br />
                <Input name="Adresse" id="adress" value={this.state.adress} onchange={handleInputChange} />
                <br />
                <Input name="Code Postal" id="postalCode" value={this.state.postalCode} onchange={handleInputChange} />
                <Input name="Ville" id="city" value={this.state.city} onchange={handleInputChange} />
                <br />
                <Select name="Type de cuisine" id="cuisine" options={this.state.cuisine} onchange={handleComboboxChange} />
                <br />
                <label className="mdl-switch mdl-js-switch mdl-js-ripple-effect" >
                    <span className="mdl-switch__label" htmlFor="aEmporter">Vente à emporter</span>
                    <input type="checkbox"
                        id="takeOut"
                        className="mdl-switch__input"
                        onChange={handleInputChange}
                        checked={this.state.takeOut} />
                </label>
                <br />
                <div className="submit-form">
                    <input type="submit"
                        onClick={handleSubmit}
                        className="mdl-button mdl-js-button mdl-button--raised" />
                </div>
                </div>
        );
    }
}

const mapDispatchtoProps= (dispatch: any) => {
    return {
        onSubmit: (restaurant: AddRestaurantState) => {
            dispatch({ type: 'ADD_RESTAURANT', restaurant })
        }
    }
}

export default connect<any,DispatchProps,any>(null,mapDispatchtoProps)(AddRestaurant);
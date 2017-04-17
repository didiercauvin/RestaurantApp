import * as React from 'react';
import { Input } from '../share/elements';

interface AddRestaurantState{
    name:string;
    adress:string;
    postalCode:string;
    city:string;
    takeOut: boolean;
}

interface RestaurantProps {
    restos?: string[];
}
export class Restaurants extends React.Component<RestaurantProps, AddRestaurantState>{

    constructor(props: RestaurantProps) {
        super(props);
        this.state = {
            name:'',
            takeOut: false,
            adress:'',
            postalCode:'',
            city:''
        };
    }

    
    componentDidMount(){
        //tricks pour typescript pour register dans gmtl
        var windowany:any = window;
        windowany.componentHandler.upgradeDom();
    }

    render() {
        const handleInputChange = (e:any) =>{
        const target = e.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.id;
        this.setState({
            [name]:value
        });
    }

        var handleSubmit = (e:any) => {
            console.log(e);
            alert('click');
          };

        return (
            <form >
                <Input name="Nom du restaurant" id="nom" value={this.state.name} onchange={handleInputChange}/>
                <br />
                <Input name="Adresse" id="adresse" value={this.state.adress} onchange={handleInputChange}/>
                <br />
                <Input name="Code Postal" id="codePostal" value={this.state.postalCode} onchange={handleInputChange}/>
                <Input name="Ville" id="ville" value={this.state.city} onchange={handleInputChange}/>
                <br />
                <label className="mdl-switch mdl-js-switch mdl-js-ripple-effect" >
                    <span className="mdl-switch__label" htmlFor="aEmporter">Vente à emporter</span>                    
                    <input type="checkbox" 
                           id="aEmporter"
                           className="mdl-switch__input"
                           onChange={handleInputChange}
                           checked={this.state.takeOut}  />
                </label>
                <br/>
                <div className="submit-form">
                <input type="submit"
                    onClick={handleSubmit} 
                    className="mdl-button mdl-js-button mdl-button--raised" />
                </div>
            </form>
        );
    }
}
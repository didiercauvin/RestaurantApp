import * as React from 'react';
import { Input } from '../share/elements';

interface AddRestaurantState{
    nom:string;
    adresse:string;
    codePostal:string;
    ville:string;
    aEmporter: boolean;
}

interface RestaurantProps {
    restos?: string[];
}
export class Restaurants extends React.Component<RestaurantProps, AddRestaurantState>{

    constructor(props: RestaurantProps) {
        super(props);
        this.state = {
            nom:'',
            aEmporter: false,
            adresse:'',
            codePostal:'',
            ville:''
        };
    }

    
    componentDidMount(){
        componentHandler.upgradeDom();
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
                <Input name="Nom du restaurant" id="nom" value={this.state.nom} onchange={handleInputChange}/>
                <br />
                <Input name="Adresse" id="adresse" value={this.state.adresse} onchange={handleInputChange}/>
                <br />
                <Input name="Code Postal" id="codePostal" value={this.state.codePostal} onchange={handleInputChange}/>
                <Input name="Ville" id="ville" value={this.state.ville} onchange={handleInputChange}/>
                <br />
                <label className="mdl-switch mdl-js-switch mdl-js-ripple-effect" >
                    <span className="mdl-switch__label" htmlFor="aEmporter">Vente à emporter</span>                    
                    <input type="checkbox" 
                           id="aEmporter"
                           className="mdl-switch__input"
                           onChange={handleInputChange}
                           checked={this.state.aEmporter}  />
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
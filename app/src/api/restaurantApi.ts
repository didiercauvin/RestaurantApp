import { Restaurant } from '../appState';
import * as request from 'superagent';


export class restaurantApi {
    static addRestaurant(restaurant: Restaurant): Promise<boolean> {
        return request.post('http://localhost:63191/api/restaurants')
        .set('Content-Type', 'application/json')
        .set('Accept','application/json')
        .send(JSON.stringify(restaurant))
        .then((res) =>{
            return res.ok;
        })
        // return fetch('http://localhost:63191/api/restaurants', {
        //     method: 'POST',
        //     headers: {
        //         'Content-Type': 'application/json'
        //     },
        //     body: JSON.stringify(restaurant)
        // }).then((response: Response) => {
        //     return response.ok;
        // })
    };


}
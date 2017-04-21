import { Cuisine } from '../appState';
import * as request from 'superagent';


export class CuisineApi {
    static getAll(): Promise<boolean> {
        return request.get('http://localhost:63191/api/cuisines')
        .set('Content-Type', 'application/json')
        .set('Accept','application/json')
        .then((res) =>{
            console.log(res);
            return res.ok;
        })
    };


}
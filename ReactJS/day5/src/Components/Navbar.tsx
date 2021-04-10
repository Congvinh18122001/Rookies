import './Navbar.css';


interface IPropsItem{
    title: string;
    price: string;
    imageUrl: string;

}

const listItems : IPropsItem[] =[
    {
        title:'Tailored Jeans',
        price:'19.99',
        imageUrl:'https://www.w3schools.com/w3images/jeans3.jpg'
    },
    {
        title:'Tailored Jeans limited',
        price:'29.99',
        imageUrl:'https://www.w3schools.com/w3images/jeans3.jpg'
    },
    {
        title:'Tailored Jeans vip pro',
        price:'39.99',
        imageUrl:'https://www.w3schools.com/w3images/jeans3.jpg'
    },
];

export function Item(props:IPropsItem){
    return(
        <div className="item">
        <h2 >Product Card</h2>

        <div className="card">
        <img src={props.imageUrl} alt="Denim Jeans" />
        <h1 className="title">{props.title}</h1>
        <p className="price">${props.price}</p>
        <p className="description">Some text about the jeans. Super slim and comfy lorem ipsum lorem jeansum. Lorem jeamsun denim lorem jeansum.</p>
        <p><button>Buy Now</button></p>
        </div>
          </div>
    );
}

export function Navbar(){
    return(
        <div>
        {listItems.map(
            (item,index) =><Item key={index} title={item.title} price={item.price} imageUrl={item.imageUrl}></Item>
            )}    
        </div>
    );
     
}
// import type { Product } from "./product";

export type Basket = {
    basketId: string
    items: Item[]
}

export type Item = {

    // constructor(product: Product, quantity: number) {
    //     this.productId = product.id;
    //     this.name = product.name;
    //     this.price = product.price;
    //     this.quantity = quantity;
    //     this.pictureUrl = product.pictureUrl;
    //     this.type = product.type;
    //     this.brand = product.brand;
    // }
    productId: number;
    name: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    type: string;
    brand: string;
}
import type { PaymentSummary, ShippingAddress } from "../app/models/order";

export function currencyFormat(amount: number){
    return '$' + (amount / 100).toFixed(2);
}

export function filterEmptyValues(values:object){
    return Object.fromEntries(
                    Object.entries(values).filter(([, v]) => v != null && v !== '' && v !== undefined && v.length !== 0)
                );
}

export const formatAddressString = (address: ShippingAddress) => {
    return `${address?.name}, ${address?.line1}, ${address?.city}, ${address?.state}, 
            ${address?.postal_code}, ${address?.country}`
}

export const formatPaymentString = (card: PaymentSummary) => {
    return `${card?.brand?.toUpperCase()}, **** **** **** ${card?.last4}, 
            Exp: ${card?.exp_month}/${card?.exp_year}`
}